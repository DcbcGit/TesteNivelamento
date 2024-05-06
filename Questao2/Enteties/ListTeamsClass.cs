namespace Questao2.Enteties
{
    public class ListTeamsClass : List<TeamClass>
    {
        public int ReturnAllGoalsTeam01(string teamName) => this.Where(t => t.Team1.Contains(teamName)).Sum(x => int.Parse(x.Team1Goals));
        public int ReturnAllGoalsTeam02(string teamName) => this.Where(t => t.Team2.Contains(teamName)).Sum(x => int.Parse(x.Team2Goals));
    }
}