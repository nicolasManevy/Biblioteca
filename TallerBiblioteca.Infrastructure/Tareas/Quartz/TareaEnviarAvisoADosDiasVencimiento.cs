using Quartz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerBiblioteca.Aplication.DAL;
using TallerBiblioteca.Aplication.Servicios.Notificacion;
using TallerBiblioteca.Aplication.Tareas;
using TallerBiblioteca.Domain.Tiempo;

namespace TallerBiblioteca.Infrastructure.Tareas.Quartz
{
    [DisallowConcurrentExecution]
    public class TareaEnviarAvisoADosDiasVencimiento : EnviarAvisosADiasDelVencimiento, IJob
    {
        public static readonly JobKey Key = new JobKey(nameof(TareaEnviarAvisoADosDiasVencimiento), "notificaciones");

        readonly List<INotificador> notificadores;
        readonly IUnitOfWorkFactory unitOfWorkFactory;
        readonly IDateTimeProvider dateTimeProvider;

        public TareaEnviarAvisoADosDiasVencimiento(IEnumerable<INotificador> pNotificadores,
                                                   IUnitOfWorkFactory pUnitOfWorkFactory,
                                                   IDateTimeProvider pDateTimeProvider)
                : base(pNotificadores, pUnitOfWorkFactory, pDateTimeProvider)
        {
            this.notificadores = pNotificadores.ToList();
            unitOfWorkFactory = pUnitOfWorkFactory;
            dateTimeProvider = pDateTimeProvider;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Ejecutar();
        }
    }
}
