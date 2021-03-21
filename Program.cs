﻿using System;
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
            //var linq = doctorHours.Where(x => x >= 9).ToList();
            //printList(linq);

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
                Scheduler(doctors, patients, result);
            }


        }

        static bool Scheduler(List<int> doctors, List<int> patients, List<string> result)
        {
            //PrintList(doctors);
            //PrintList(patients);
            //Console.WriteLine();
            if (patients.Count == 0)
            {
                //PrintList(doctors);
                //PrintList(patients);
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
                    result.Add($"{patients[0]} hours added to Doctor[{i}] ({doctors[i]}), doctor now has {newDocs[i]} hours remaining");
                    callSuccessful = Scheduler(newDocs, newPats, result);
                    if (callSuccessful) return true;
                    else result.RemoveAt(result.Count - 1);
                }                
            }
            return false;
        }

        static void PrintStack(Stack<string> stack)
        {
            Console.WriteLine("Printing Schedule:");
            var list = new List<string>();
            for (int i = 0; i < stack.Count; i++)
            {
                list.Add(stack.Pop());
            }
            list.ForEach(x => Console.WriteLine(x));
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
