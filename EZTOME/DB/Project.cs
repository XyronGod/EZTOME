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
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.Work = new HashSet<Work>();
        }
    
        public int IDProject { get; set; }
        public string LoginClient { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string Status { get; set; }
        public string Service { get; set; }
        public string DescClient { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Services Services { get; set; }
        public virtual StatusProject StatusProject { get; set; }
        public virtual Team Team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Work { get; set; }
    }
}