//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BooksShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookToOrder
    {
        public int IDbookToOrder { get; set; }
        public Nullable<int> IDbook { get; set; }
        public Nullable<int> IDorder { get; set; }
        public Nullable<int> count { get; set; }
    
        public virtual books books { get; set; }
        public virtual orders orders { get; set; }
    }
}
