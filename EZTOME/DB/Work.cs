//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZTOME.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Work
    {
        public int IDWork { get; set; }
        public string LoginEmployer { get; set; }
        public int IDProject { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    
        public virtual Employers Employers { get; set; }
        public virtual Project Project { get; set; }
        public virtual StatusWork StatusWork { get; set; }
    }
}
