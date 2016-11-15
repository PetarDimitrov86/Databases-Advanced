namespace HospitalDatabase
{
    using HospitalDatabase.Models;

    class Program
    {
        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();

            context.Medicaments.Add(new Medicament {Name = "Paracetamol"});

            context.SaveChanges();
        }                                       
    }
}
