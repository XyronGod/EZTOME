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
    
    public partial class Employers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employers()
        {
            this.Team1 = new HashSet<Team>();
            this.Work = new HashSet<Work>();
        }
    
        public string Login { get; set; }
        public string Password { get; set; }
        public string FisrstName { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public Nullable<int> TeamID { get; set; }
        public string Role { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Team Team { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Team1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Work { get; set; }
    }
}
