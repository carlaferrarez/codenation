using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private Dictionary<long, Player> player;
        private Dictionary<long, Team> team;

        public SoccerTeamsManager()
        {
            player = new Dictionary<long, Player>();
            team = new Dictionary<long, Team>();

        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (team.ContainsKey(id))
            {
                throw new UniqueIdentifierException();
            }

            Team teamgeneric = new Team()
            {
                Id = id,
                Name = name,
                CreateDate = createDate,
                MainShirtColor = mainShirtColor,
                SecondaryShirtColor = secondaryShirtColor,
            };

            team.Add(id, teamgeneric);
         
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {

            if (player.ContainsKey(id))
            {
                throw new UniqueIdentifierException();
            }
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }

            Player playergeneric = new Player()
            {
                Id = id,
                TeamId = teamId,
                Name = name,
                BirthDate = birthDate,
                SkillLevel = skillLevel,
                Salary = salary,
            };

            player.Add(id, playergeneric);
        }

        public void SetCaptain(long playerId)
        {
            if (!player.ContainsKey(playerId))
            {
                throw new PlayerNotFoundException();
            }

            team[player[playerId].TeamId].CaptainId = playerId;
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }
            if (!team.ContainsKey(team[teamId].CaptainId))
            {
                throw new CaptainNotFoundException();
            }

            return team[teamId].CaptainId;
        }

        public string GetPlayerName(long playerId)
        {

            if (!player.ContainsKey(playerId))
            {
                throw new PlayerNotFoundException();
            }
            return player[playerId].Name; //player é meu dict: tem todos os players indexados com id unico > Name está definido na Classe

        }

        public string GetTeamName(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }
            return team[teamId].Name;
        }

        private IEnumerable<Player> GetPlayersOnTeam(long teamId)
        {
            return player.Values.Where(x => x.TeamId == teamId);

        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }

            return GetPlayersOnTeam(teamId).Select(x => x.Id)
                .OrderBy(x => x)
                .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }


            return GetPlayersOnTeam(teamId).OrderByDescending(x => x.SkillLevel).ThenBy(n => n.Id).First().Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }

            return GetPlayersOnTeam(teamId).Select(x => x).OrderBy(x => x.BirthDate).ThenBy(n => n.Id).First().Id;
 
        }

        private IEnumerable<long> GetAllTeamsId()
        {
            return team.Values.Select(teams => teams.Id).OrderBy(teams => teams);

        }

        public List<long> GetTeams()
        {
            if (team == null)
            {
                return null;
            }

            return GetAllTeamsId().ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }

            Player highersalaryplayer = GetPlayersOnTeam(teamId).Select(x => x).OrderBy(x => x.Salary).ToList().Last();
            return highersalaryplayer.Id;

        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!player.ContainsKey(playerId))
            {
                throw new PlayerNotFoundException();
            }
            return player[playerId].Salary;
        }

        private IEnumerable<Player> GetAllPlayersbySkillLevel()
        {

            return player.Values.Select(x => x).OrderByDescending(x => x.SkillLevel).ThenBy(x => x.Id);

        }

        public List<long> GetTopPlayers(int top)
        {
            if (player == null)
            {
                return null;
            }
            return GetAllPlayersbySkillLevel().Select(x => x.Id).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!team.ContainsKey(teamId))
            {
                throw new TeamNotFoundException();
            }

            if (!team.ContainsKey(visitorTeamId))
            {
                throw new TeamNotFoundException();
            }

            if (team[teamId].MainShirtColor == team[visitorTeamId].MainShirtColor)

            {
                return team[visitorTeamId].SecondaryShirtColor;
            }

            else

            {
                return team[visitorTeamId].MainShirtColor;
            }
        }

        public static void Main()
        {
            //var treinador = new SoccerTeamsManager();
            //treinador.AddTeam(1, "sp", DateTime.Now, "roxo", "laranja");
            //treinador.AddPlayer(1, 1, "caio", DateTime.Now, 6, 10);
            //treinador.AddPlayer(2, 1, "carla", DateTime.Now, 4, 10);
            //treinador.AddPlayer(3, 1, "andre", DateTime.Now, 400, 10);

            //Console.WriteLine("resultado do main" + treinador.GetBestTeamPlayer(1));
            //Console.WriteLine("resultado do main GET TOP PLAYERS" + treinador.GetTopPlayers(2));

        }
    }
}
