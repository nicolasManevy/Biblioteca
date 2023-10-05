using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Aplication.Log;
using TallerBiblioteca.Aplication.Servicios.Notificacion;
using TallerBiblioteca.Domain.Modelos;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Aplication.Tareas
{
    public class EnviarAvisosADiasDelVencimiento
    {
        readonly List<INotificador> notificadores;
        readonly IUnitOfWorkFactory unitOfWorkFactory;
        readonly IDateTimeProvider dateTimeProvider;

        public EnviarAvisosADiasDelVencimiento(
                                               IEnumerable<INotificador> pNotificadores,
                                               IUnitOfWorkFactory pUnitOfWorkFactory,
                                               IDateTimeProvider pDateTimeProvider)
        {
            this.notificadores = pNotificadores.ToList();
            unitOfWorkFactory = pUnitOfWorkFactory;
            dateTimeProvider = pDateTimeProvider;
        }

        public Task Ejecutar()
        {
            using (IUnitOfWork bUoW = unitOfWorkFactory.Crear())
            {
                //  1. Obtener los prestamos que estén a X días a vencer 
                //     y que no se les haya enviado el mail de aviso de vencimiento
                var resultado = bUoW.RepositorioNotificacionVencimientoPrestamo
                                        .ObtenerPrestamosQueEstenPorVencerYNoSeNotifico(dateTimeProvider.Now);

                LogManager.GetLogger().Debug($"[TareaEnviarAvisoADosDiasVencimiento] Mails a enviar: {resultado.Count}");

                //  2. Enviar el mail para cada uno
                foreach (var prestamo in resultado)
                {
                    foreach (var notificador in notificadores)
                    {
                        // El usuario podría tener una configuración de si desea recibir o no notificaciones de este tipo

                        if (notificador.Enviar("Vencimiento de préstamo", "Tu prestamos esta proximo a vencer a 2 días", prestamo.Solicitante))
                        {
                            LogManager.GetLogger().Info("[TareaEnviarAvisoADosDiasVencimiento] Enviado el mail de vencimiento");

                            //  3. Si fue exitoso: Actualizar el préstamo, indicando que ya se envió el mail.
                            NotificacionVencimientoPrestamo notificacionVencimientoPrestamo = new NotificacionVencimientoPrestamo
                            {
                                Prestamo = prestamo,
                                FechaEnvio = dateTimeProvider.Now
                            };

                            bUoW.RepositorioNotificacionVencimientoPrestamo.Agregar(notificacionVencimientoPrestamo);
                        } else
                        {
                            //  4. Sino, seguir con el siguiente.
                            LogManager.GetLogger().Warn("No se puedo envir la notificacion de vencimiento");
                        }
                    }
                }

                bUoW.Commit();
            }

            return Task.CompletedTask;
        }
    }
}
