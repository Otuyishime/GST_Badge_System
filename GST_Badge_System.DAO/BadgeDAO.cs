using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using CsvHelper;

namespace GST_Badge_System.DAO
{
    /*
     This class will be used to read/write all the badge data from the data database
     */
    public class BadgeDAO //: IcrudOperations<Badge>
    {
        public Badge create(Badge element)
        {
            throw new NotImplementedException();
        }

        public int delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Badge> list()
        {
            throw new NotImplementedException();
        }

        public Badge retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public Badge update(Badge element)
        {
            throw new NotImplementedException();
        }

        public List<Badge> ImportBadges(string filePath)
        {
            List<Badge> badges = new List<Badge>();

            // Read the file and display it line by line.
            using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
            {
                var csv = new CsvReader(file);

                while (csv.Read())
                {
                    Badge temp_badge = new Badge();

                    var number = csv.GetField<int>("Number");
                    var name = csv.GetField<string>("Name");
                    var descript = csv.GetField<string>("Summary");
                    var dateActive = csv.GetField<string>("Date Activated");
                    var dateRetire = csv.GetField<string>("Date Retired");
                    var notes = csv.GetField<string>("Notes");
                    var imageURL = csv.GetField<string>("Image website address");

                    temp_badge.Badge_Id = number;
                    temp_badge.Badge_Name = name;
                    temp_badge.Badge_Descript = descript;
                    temp_badge.Badge_Image = imageURL;

                    if (!String.IsNullOrEmpty(dateActive))
                    {
                        temp_badge.Badge_ActivateDate = Convert.ToDateTime(dateActive);
                    }

                    if (!String.IsNullOrEmpty(dateRetire))
                    {
                        temp_badge.Badge_RetireDate = Convert.ToDateTime(dateRetire);
                    }

                    if (!String.IsNullOrEmpty(notes))
                    {
                        temp_badge.Badge_Notes = notes;
                    }

                    // add the badge to the list
                    badges.Add(temp_badge);
                }
            }

            return badges;
        }

        public int uploadBadges()
        {
            return 1;
        }
    }
}
