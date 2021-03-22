using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] doctorHours = { 7, 2, 4, 2 };
            int[] patientHours = { 1, 2, 5, 3, 1, 2, 1 };
            Scheduler(doctorHours, patientHours);
        }

        static void Scheduler(int[] doctorHours, int[] patientHours)
        {
            if (patientHours.Sum() > doctorHours.Sum()) Console.WriteLine("Not all patients can be seen!");
            else
            {
                var doctors = doctorHours.ToList();
                var patients = patientHours.ToList();
                var result = new List<string>();
                for (int i = 0; i < doctors.Count; i++)
                {
                    result.Add($"Doctor {i + 1}'s Appointments: ");
                }
                Scheduler(doctors, patients, result);
            }
        }

        static bool Scheduler(List<int> doctors, List<int> patients, List<string> result)
        {
            if (patients.Count == 0)
            {
                result.ForEach(x => Console.WriteLine(x));
                return true;
            }
            for (int i = 0; i < doctors.Count; i++)
            {
                var newDocs = new List<int>(doctors);
                var newPats = new List<int>(patients);
                bool callSuccessful;
                if (doctors[i] >= patients[0])
                {
                    newDocs[i] -= patients[0];
                    newPats.RemoveAt(0);
                    int savedStringLength = result[i].Length;
                    result[i] += $"{patients[0]}hr ";
                    callSuccessful = Scheduler(newDocs, newPats, result);
                    if (callSuccessful) return true;
                    else result[i] = result[i].Substring(0, savedStringLength);
                }                
            }
            return false;
        }

        static void PrintList(List<int> list)
        {
            Console.Write("{");
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }
            Console.Write("}\n");
        }
    }
}
