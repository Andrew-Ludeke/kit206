﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    enum EmploymentLevel { A, B, C, D, E, Student }

    enum PublicationType
    { 
        Conference,
        Journal,
        Other
    }

    enum Campus
    {
        HOBART,
        LAUNCESTON,
        CRADLE_COAST

    }
    enum ReportType
    {
        POOR,
        BELOW_EXPECTATIONS,
        MINIMUM_STANDARD,
        STAR_PERFORMANCE
    }

    enum ResearcherType
    { 
        Staff,
        Student
    }

    class Program
    {
        static void Main(string[] args)
        {
            //testdb();
        }

        static void testdb()
        {
            List<Model.Researcher> rs =
                Database.ResearcherAdapter.fetchResearcherList();
            Console.WriteLine("fetchResearcherList():");
            foreach (Model.Researcher researcher in rs)
                Console.WriteLine(researcher);
            Console.WriteLine("");

            Model.Researcher r =
                Database.ResearcherAdapter.fetchResearcherDetails(rs[0]);
            Console.WriteLine("fetchResearcherDetails():");
            Console.WriteLine(r.ToFullString());

            List<Model.Publication> ps =
                Database.PublicationAdapter.fetchPublicationsList(r);
            Console.WriteLine("fetchPublicatoinsList():");
            foreach (Model.Publication publication in ps)
                Console.WriteLine(publication);
            Console.WriteLine("");

            Model.Publication p =
                Database.PublicationAdapter.fetchPublicationDetails(ps[0]);
            Console.WriteLine("fetchPublicationDetails():");
            Console.WriteLine(p.ToFullString());
            Console.WriteLine("");

            List<string> emails =
                Database.ReportAdapter.fetchResearcherEmails(rs);
            Console.WriteLine("fetchResearcherEmails():");
            foreach (string email in emails)
                Console.WriteLine(email);
            Console.WriteLine("");

            List<Model.Student> supervisions =
                Database.ResearcherAdapter.fetchSupervisions(
                    (Model.Staff)rs[1]);
            Console.WriteLine("fetchSupervisions():");
            foreach (Model.Student supervision in supervisions)
                Console.WriteLine(supervision);
            Console.WriteLine("");

            int numSupervisions =
                Database.ResearcherAdapter.fetchNumSupervisions(
                    (Model.Staff)rs[1]);
            Console.WriteLine("fetchNumSupervisions():");
            Console.WriteLine(numSupervisions);
            Console.WriteLine("");

            List<Model.Staff> staffList =
                Database.ReportAdapter.fetchStaffList();
            Console.WriteLine("fetchStaffList():");
            foreach (Model.Staff staff in staffList)
                Console.WriteLine(staff);
            Console.WriteLine("");
        }

    }
}
