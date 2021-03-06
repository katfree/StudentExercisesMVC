﻿using Microsoft.AspNetCore.Mvc.Rendering;
using StudentExercisesMVC2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC2.Models.ViewModels
{
    public class StudentEditViewModel
    {
        // A single student
        public Student Student { get; set; } = new Student();

        // All cohorts
        [Display(Name = "Select Cohort")]
        public List<SelectListItem> Cohorts;

        public string _connectionString;

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }


        public StudentEditViewModel() { }

        public StudentEditViewModel(int id, string connectionString)
        {
            _connectionString = connectionString;
            GetAllCohorts();
            Student = StudentRepository.GetStudent(id, connectionString);
        }

        public void GetAllCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.CohortName from Cohort c";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };

                        cohorts.Add(cohort);
                    }

                    Cohorts = cohorts.Select(li => new SelectListItem
                    {
                        Text = li.CohortName,
                        Value = li.Id.ToString()
                    }).ToList();

                    Cohorts.Insert(0, new SelectListItem
                    {
                        Text = "Choose cohort...",
                        Value = "0"
                    });
                }
            }
        } }
}
