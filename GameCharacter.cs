namespace bosstest
{
    internal class GameCharacter
    {
        private readonly GamePlay _gamePlay;

        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Stamina { get; private set; }
        public int OriginalHealth { get; }
        public int OriginalStrength { get; }
        public int OriginalStamina { get; }

        public GameCharacter(int health, int strength, int stamina)
        {
            Health = OriginalHealth = health;
            Strength = OriginalStrength = strength;
            Stamina = OriginalStamina = stamina;
            _gamePlay = new GamePlay();
        }

        public void Fight(GameCharacter enemy, int possibleDamage = 0)
        {
            if (Stamina <= 0) Recharge();
            else
            {
                enemy.Health -= (possibleDamage > 0) ? possibleDamage : Strength;
                DrainStamina(10);
            }
        }

        public void DrainStamina(int staminaDrain)
        {
            Stamina -= staminaDrain;
        }

        public void Recharge()
        {
            Stamina = OriginalStamina;
        }

        public void DrinkHealthPotion()
        {
            if (_gamePlay.GetItemByName("HealthPotion").Name == "HealthPotion") Health = OriginalHealth;
        }

        public void DrinkStaminaPotion()
        {
            if (_gamePlay.GetItemByName("StaminaPotion").Name == "StaminaPotion") Recharge();
        }

        public void DrinkStrengthPotion(GameCharacter enemy)
        {
            if (_gamePlay.GetItemByName("StrengthPotion").Name == "StrengthPotion") enemy.Health -= 30;
        }
    }
}