using System;

namespace NullableLab
{
    public class UserProfile
    {
        
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsStudent { get; set; }

        public void Print(string title)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine(title);
            Console.WriteLine("---------------------------------------");

            
            Console.WriteLine($"Age:       {(Age == null ? "<null>" : Age.ToString())}");

            
            if (BirthDate.HasValue)
                Console.WriteLine($"BirthDate: {BirthDate.Value:yyyy-MM-dd}");
            else
                Console.WriteLine("BirthDate: <null>");

            
            Console.WriteLine($"Email:     {Email ?? "<null>"}");
            Console.WriteLine($"Phone:     {Phone ?? "<null>"}");

            
            string studentText = IsStudent switch
            {
                true => "так",
                false => "нi",
                null => "<null>"
            };
            Console.WriteLine($"IsStudent: {studentText}");

            Console.WriteLine("=======================================\n");
        }

        
        public void ClearAll()
        {
            Age = null;
            BirthDate = null;
            Email = null;
            Phone = null;
            IsStudent = null;
        }
    }
}