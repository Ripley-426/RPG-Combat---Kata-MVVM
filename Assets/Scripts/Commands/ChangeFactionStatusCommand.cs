using ViewModel;

namespace Commands
{
    public class ChangeFactionStatusCommand : ICommand
    {
        private readonly CharacterData _character;
        private readonly CharacterFaction _faction;

        public ChangeFactionStatusCommand(CharacterData character, CharacterFaction faction)
        {
            _character = character;
            _faction = faction;
        }
        public void Execute()
        {
            if (_character.factions.Contains(_faction))
            {
                _character.factions.Remove(_faction);
            }
            else
            {
                _character.factions.Add(_faction);
            }
        }
    }
}