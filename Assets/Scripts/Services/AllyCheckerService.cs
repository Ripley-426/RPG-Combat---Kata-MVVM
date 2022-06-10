using ViewModel;

namespace Services
{
    public class AllyCheckerService
    {
        private readonly CharacterData _player;
        private readonly CharacterData _opponent;

        public AllyCheckerService(CharacterData player, CharacterData opponent)
        {
            _player = player;
            _opponent = opponent;
        }

        public bool IsAlly()
        {
            if (_player.factions.Count == 0) return false;
            
            foreach (var characterFaction in _player.factions)
            {
                if (_opponent.factions.Contains(characterFaction)) return true;
            }

            return false;
        }
    }
}