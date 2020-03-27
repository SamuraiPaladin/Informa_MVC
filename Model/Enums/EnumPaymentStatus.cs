using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Enums
{
    public class EnumPaymentStatus
    {
        public enum PaymentStatus
        {
            Pago,
            [Display(Name = "Pago com atraso")]
            PagoComAtraso, 
            Vencido,
            [Display(Name = "Próximo da data de vencimento")]
            ProximoDaDataDeVencimento,
            [Display(Name = "Em Haver")]
            EmHaver
        };
    }
}
