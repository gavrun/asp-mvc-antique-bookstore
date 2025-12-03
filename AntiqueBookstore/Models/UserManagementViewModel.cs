using Microsoft.AspNetCore.Mvc.Rendering;

namespace AntiqueBookstore.Models
{
    public class UserManagementViewModel
    {
        // UserViewModel + UserManagementViewModel class corresponding to User entity for UserManagement

        public List<UserViewModel> Users { get; set; }
        public SelectList UnlinkedEmployees { get; set; } // list for Assign Role (modal dialogue)

        public UserManagementViewModel()
        {
            Users = new List<UserViewModel>();
        }
    }
}
