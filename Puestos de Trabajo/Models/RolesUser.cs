namespace Puestos_de_Trabajo.Models
{
    public class RolesUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetRoles AspNetRoles { get; set; }
    }
}