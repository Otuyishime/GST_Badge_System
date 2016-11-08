using GST_Badge_System.Model;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using CsvHelper;
using System.Data;

namespace GST_Badge_System.DAO
{
	/*
	 This class will be used to read/write all the badge data from the data database
	 */
	public class BadgeDAO //: IcrudOperations<Badge>
	{
		private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=gst_badge_system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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

		// push badges to database
		private void pushBadgeHelper(IDbConnection conn, string badgetypename, string filepath2)
		{
			foreach (Badge badge in ImportBadges(""))
			{
				string image, name, descript, notes, activedate, retiredate;
				int number, typeid, givetypeid, statusid;

				number = badge.Badge_Id;
				name = badge.Badge_Name;
				descript = badge.Badge_Descript;
				notes = badge.Badge_Notes;
				image = badge.Badge_Image;
				activedate = badge.Badge_ActivateDate.ToShortDateString();
				givetypeid = new BadgeGiveTypeDAO()[badgetypename].BGT_Id;
				statusid = new BadgeStatusDAO()["Active"].BS_Id;
				retiredate = null;


				if (badge.Badge_RetireDate != null)
				{
					retiredate = badge.Badge_RetireDate.ToShortDateString();
					statusid = new BadgeStatusDAO()["DeActivated"].BS_Id;
				}

				string sql = @"INSERT INTO Badge (Badge_Id, Badge_Name, Badge_Descript, Badge_ActivateDate, Badge_RetireDate, 
									Badge_Notes, Badge_Image, BadgeGiveType, BadgeStatus) 
									VALUES ( @number, @name, @descript, @activedate, @retiredate, @notes, @image, @givetypeid,
												@statusid);";
				conn.Execute(sql, new { number, name, descript, activedate, retiredate, notes, image, givetypeid, statusid });
			}
		}

		// upload badges to the database
		public int uploadBadges()
		{
			using (var conn = new SqlConnection(connectionString))
			{
				// get the badge give type
				// Student to peer
				pushBadgeHelper(conn, "Student to peer", "");

				// Student to self
				pushBadgeHelper(conn, "Student to self", "");

				// Faculty to student
				pushBadgeHelper(conn, "Faculty to student", "");

				// Staff to student
				pushBadgeHelper(conn, "Staff to student", "");

			}
			return 1;
		}
	}
}
