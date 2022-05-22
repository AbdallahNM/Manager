namespace Manager.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string? ExistingImagePath { get; set; }
       
    }
}
