using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Utilities
{
    public class ViewCriminals
    {
        public static void ViewCriminal()
        {
            Console.WriteLine("Criminal ID:");
            string id = Console.ReadLine();
            if (int.TryParse(id, out int result) == false)
            {
                Console.WriteLine("NaN");
                return;
            }
            int _id = int.Parse(id);
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var criminal = unitOfWork.CriminalRepository.Get(_id);
                if (criminal == null)
                {
                    Console.WriteLine("No criminal with such id");
                    return;
                }
                Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public static void ViewAllCriminals()
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var criminals = unitOfWork.CriminalRepository.GetAll();
                foreach (var criminal in criminals)
                    Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }
    }
}
