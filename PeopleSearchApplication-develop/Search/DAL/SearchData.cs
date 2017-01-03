using System.Collections.Generic;
using System.Linq;
using Search;

namespace PeopleSearch.DAL
{

    public interface IsearchData
    {
       List<SearchModel> GetPersonDetails(string filter);
    }
    public class SearchData : IsearchData    
    {
    private PeopleSearchEntities _db;
    public SearchData()
    {

    }
    public SearchData(PeopleSearchEntities db)
    {
        _db = db;
    }


    public List<SearchModel> PersonList()
    {
            List<SearchModel> people = new List<SearchModel>();
            people.Add(
                        new SearchModel
                        {
                            FirstName = "Danny",
                            LastName = "Aguilar",
                            Team = "Justice League/Xmen",
                            Avatar = "Batman"
                        }
                      );
            people.Add(
                        new SearchModel
                        {
                            FirstName = "Ranadheer",
                            LastName = "Kolli",
                            Team = "Justice League",
                            Avatar = "Superman"
                        }
                       );
            people.Add(
                    new SearchModel
                    {
                        FirstName = "Ray",
                        LastName = "Loveless",
                        Team = "Justice League",
                        Avatar = "Green Arrow"
                    }
                );

            people.Add(
                  new SearchModel
                  {
                      FirstName = "Jeff",
                      LastName = "Arrowsmith",
                      Team = "Justice League",
                      Avatar = "XXX"
                  }
              );
            people.Add(
                  new SearchModel
                  {
                      FirstName = "Michael",
                      LastName = "Rentmeister",
                      Team = "Justice League",
                      Avatar = "XXX"
                  }
              );

            return people;

    }
    public List<SearchModel> GetPersonDetails(string filter)
        {
            List<SearchModel> details = new List<SearchModel>();

            if (_db == null)
            {
                _db = new PeopleSearchEntities();
            }

            //var details = (from pd in _db.PersonDetails
            //               join p in _db.Pictures on pd.PersonId equals p.PersonId
            //               where (pd.FirstName.Contains(filter) || pd.LastName.Contains(filter))
            //               select new SearchModel
            //               {
            //                   PersonId = pd.PersonId,
            //                   FirstName = pd.FirstName,
            //                   LastName = pd.LastName,
            //                   Age = pd.Age,
            //                   Address = pd.Address,
            //                   Interests = pd.Interests,
            //                   Image = p.Picture1
            //               }).ToList();

            List<SearchModel> people = PersonList();

            foreach(var item in people)
            {
                if(item.FirstName.ToLower().Contains(filter) || item.LastName.ToLower().Contains(filter))
                {
                    details.Add(item);
                }
                  
            }

            return details;

        }
    }
}