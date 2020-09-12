using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Enums
{
    public class EnumPaymentStatus
    {
        public enum PaymentStatus
        {
            Pago,
            PagoComAtraso, 
            Vencido,
            ProximoDaDataDeVencimento,
            EmHaver
        };
    }
}
