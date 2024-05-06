using Newtonsoft.Json;
using Questao2.Enteties;

namespace Questao2.Operations
{
    public class TeamsOperationsClass
    {
        private string _nameTeam;
        private int _year;
        private ListTeamsClass _lstGamesTeams = new ListTeamsClass();

        public int GetGoalsbyYear(string team, int year)
        {
            _nameTeam = team;
            _year = year;
            FillListTeams(1);
            FillListTeams(2);

            int goals1 = _lstGamesTeams.ReturnAllGoalsTeam01(team);
            int goals2 = _lstGamesTeams.ReturnAllGoalsTeam02(team);

            return goals1 + goals2;
        }

        private void FillListTeams(int team) 
        {
            PageClass pg = new PageClass();
            using (OperationHttpClass opHttp = new OperationHttpClass())
            {
                do
                {
                    pg = JsonConvert.DeserializeObject<PageClass>(opHttp.ExecutaUrl(PrepareParameters(pg.Page + 1, team)));
                    _lstGamesTeams.AddRange(pg.Teams);
                } while (pg.Page != pg.TotalPages);
            }
        }

        private string PrepareParameters(int page, int team) => $"?year={_year}&team{team}={_nameTeam}&page={page}";

    }
}