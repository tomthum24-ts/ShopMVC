namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Scritp_Header
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public string Code { get; set; }

        public string Note { get; set; }
        public bool? Status { get; set; }
    }
}
