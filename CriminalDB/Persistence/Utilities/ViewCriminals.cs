using CriminalDB.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static CriminalDB.Persistence.Utilities.GenericParser;

namespace CriminalDB.Persistence.Utilities
{
    public class ViewCriminals
    {
        public static void ViewCriminal()
        {
            int id = ParseValue<int>(int.TryParse, "Criminal ID:");
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var criminal = unitOfWork.CriminalRepository.Get(id);
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

        public static void ViewCriminalWithInfo()
        {

        }
    }
}
