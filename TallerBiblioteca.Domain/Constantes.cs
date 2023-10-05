namespace TallerBiblioteca.Domain
{
    static public class Constantes
    {
        static public class Puntaje
        {
            /// <summary>
            /// Puntaje de penalización aplicable cuando el ejemplar es devuelto en malas condiciones.
            /// </summary>
            public const int PuntajePorEjemplarEnMalasCondiciones = -10;

            /// <summary>
            /// Puntaje de penalización aplicable cuando el ejemplar es devuelto fuera de plazo.
            /// Este puntaje de penalización es por cada dia de mora.
            /// </summary>
            public const int PuntajePorEjemplarFueraDePlazoPorDiaDeMora = -2;

            /// <summary>
            /// Puntaje por devolver un ejemplar de manera correcta.
            /// </summary>
            public const int PuntajePorEjemplarDevueltoCorrectamente = 5;

            /// <summary>
            /// Por cada 5 puntos de puntaje, se puede extender el préstamo un día.
            /// </summary>
            public const int PuntajeNecesarioParaExtenderElPrestamoUnDia = 5;
        }

        static public class Prestamo
        {
            /// <summary>
            /// Cantidad de días base de préstamo.
            /// </summary>
            public const int DiasBaseDePrestamo = 5;

            /// <summary>
            /// Cantidad de días máximos de préstamo.
            /// </summary>
            public const int DiasMaximoDePrestamo = 15;

            /// <summary>
            /// Dias de antelación para enviar la notificación de vencimiento.
            /// </summary>
            public const int DiasAntelacionAvisoVencimiento = 2;
        }
    }
}
