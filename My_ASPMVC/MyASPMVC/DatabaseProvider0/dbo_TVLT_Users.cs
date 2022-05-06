namespace DatabaseProvider0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[dbo.TVLT_Users]")]
    public partial class dbo_TVLT_Users
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Uid { get; set; }

        [StringLength(50)]
        public string Pwd { get; set; }

        [StringLength(50)]
        public string Fullname { get; set; }
    }
}
