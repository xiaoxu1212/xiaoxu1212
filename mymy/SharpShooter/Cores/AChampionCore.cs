using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;

namespace SharpShooter
{
    public abstract class AChampionCore
    {
        protected Menu MainMenu;
        protected Menu QMenu;
        protected Menu WMenu;
        protected Menu EMenu;
        protected Menu RMenu;
        protected Menu DrawMenu;

        protected Spell Q;
        protected Spell W;
        protected Spell E;
        protected Spell R;

        protected readonly AIHeroClient Player;

        protected AChampionCore()
        {
            Player = GameObjects.Player;

            GameEvent.OnGameLoad += OnChampionLoad;
        }

        protected abstract void SetupSpells();
        protected abstract void SetupMenus();
        protected abstract void SetupEvents();

        private void OnChampionLoad()
        {
            SetupSpells();
            SetupMenus();
            SetupEvents();
        }
    }
}
