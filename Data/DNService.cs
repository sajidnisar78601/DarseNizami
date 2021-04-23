
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarseNizami.Data
{
    public class DNService
    {
        public Task<List<DNViewModel>> GetDNBooksAsync()
        {
            var lstDN = new List<DNViewModel>();
            

            using (SqliteConnection db =
                new SqliteConnection("Filename=darsenizami.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    (@"select bd.blbID,b.bookID,b.bookName,a.AuthorName, t.TeacherName,L.LanguageName, f.FunNameArabic,f.FunNameEng,
d.DarajaNameArabic,d.DarajaNameEng
, b.BookImagePath
from booksLecturesBundles bd
inner join books b on b.bookID = bd.bookID
inner join Teachers t on t.TeacherID = bd.TeacherID
inner join Languages l on bd.LecturesLangugeID = l.LanguageID
inner join Funoon f on b.FunID = f.FunID
inner join Authors a on b.authorID = a.authorID
inner join Darajat d on b.DarajahID = d.DarajahID", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                //                bd.blbID,b.bookID,b.bookName,a.AuthorName, t.TeacherName,L.LanguageName, f.FunNameArabic,f.FunNameEng, 
                //d.DarajaNameArabic,d.DarajaNameEng
                while (query.Read())
                {
                    lstDN.Add(new DNViewModel()
                    {
                        BundleID = query.GetString(0),
                        BookID = query.GetString(1),
                        BookName = query.GetString(2),
                        AuthorName = query.GetString(3),
                        TeacherName = query.GetString(4),
                        LanguageName = query.GetString(5),
                        FunNameArabic = query.GetString(6),
                        FunNameEng = query.GetString(7),
                        DarajaNameArabic = query.GetString(8),
                        DarajaNameEng = query.GetString(9)
                    ,
                        BookTitle = query.GetString(2)
                    ,
                        BookImagePath = query.GetString(10)
                    });
                }

                db.Close();
            }

           
            return Task.FromResult(lstDN);
        }
    }
}
