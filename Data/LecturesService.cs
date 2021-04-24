using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarseNizami.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesServiceController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var titles = await GetBookLecturesByIdAsync(id);
            return Ok(titles);
        }

     

        public Task<List<Lecture>> GetBookLecturesByIdAsync(int bookID)
        {
            var lstDN = new List<Lecture>();
            

            using (SqliteConnection db =
                new SqliteConnection("Filename=darsenizami.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                  (@"select 
lec.Name as LectureName, lec.Duration, lec.Title as LectureTitle,Sno,lec.LastPlayed
from booksLecturesBundles bd
inner join books b on b.bookID = bd.bookID
inner join lectures lec on bd.blbID = lec.blbID
inner join Teachers t on t.TeacherID = bd.TeacherID
inner join Languages l on bd.LecturesLangugeID = l.LanguageID
inner join Funoon f on b.FunID = f.FunID
inner join Authors a on b.authorID = a.authorID
inner join Darajat d on b.DarajahID = d.DarajahID where bd.blbID = '" + bookID + "'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    lstDN.Add(new Lecture() {
                        LectureName = query.GetString(0),
                        LectureDuration = query.GetString(1),
                        LectureTitle = query.GetString(2),
                        LectureID = query.GetString(3),
                        LastPlayed = query.IsDBNull(4) ? 0 : query.GetInt32(4)
                    });
                }

                db.Close();
            }


            return Task.FromResult(lstDN);
        }
    }
}
