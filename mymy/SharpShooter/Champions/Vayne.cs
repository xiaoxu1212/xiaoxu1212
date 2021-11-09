using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using SharpDXColor = SharpDX.Color;

namespace SharpShooter.Champions
{
    /// <summary>
    ///    Vayne script
    /// </summary>
    public class Vayne : AChampionCore
    {
        protected override void SetupSpells()
        {
            Q = new Spell(SpellSlot.Q, 300f);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 650f) { Delay = 0.25f };
            R = new Spell(SpellSlot.R);
        }

        protected override void SetupMenus()
        {
            MainMenu = new Menu(Player.CharacterName, "[SharpShooter] " + Player.CharacterName, true).Attach();
            {
                QMenu = MainMenu.Add(new Menu("Q", "[Q] Tumble"));
                {

                }

                WMenu = MainMenu.Add(new Menu("W", "[W] Silver Bolts"));
                {

                }

                EMenu = MainMenu.Add(new Menu("E", "[E] Condemn"));
                {

                }

                RMenu = MainMenu.Add(new Menu("R", "[R] Final Hour"));
                {

                }

                DrawMenu = MainMenu.Add(new Menu("Draw", "Draw Range"));
                {
                    DrawMenu.Add(new MenuBool("E", "Draw E Range"));
                    DrawMenu.Add(new MenuColor("EColor", "^ Circle Color", SharpDXColor.AliceBlue));
                    DrawMenu.Add(new MenuSeparator("xx", " "));
                    DrawMenu.Add(new MenuBool("OnlyReady", "Draw Only Spell Ready"));
                }
            }
        }

        protected override void SetupEvents()
        {
            AIBaseClient.OnDoCast += OnDoCast;
            AntiGapcloser.OnGapcloser += OnGapcloser;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            Orbwalker.OnAfterAttack += OnAfterAttack;
            GameEvent.OnGameTick += OnTick;
            Drawing.OnDraw += OnDraw;
        }

        private void OnComboUpdate()
        {
            
        }

        private void OnHarassUpdate()
        {
            
        }

        private void OnLaneClearUpdate()
        {
            
        }

        private void OnJungleClearUpdate()
        {
            
        }

        private void OnLastHitUpdate()
        {
            
        }

        private void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
        {
            if (sender == null || !sender.IsValid || sender.GetType() != typeof(AIHeroClient) || !sender.IsEnemy)
            {
                return;
            }

            // fuck off alistar
            if (sender.CharacterName == "Alistar" && args.Slot == SpellSlot.W && args.Target != null && args.Target.IsValid && args.Target.IsMe)
            {
                if (E.IsReady())
                {
                    E.CastOnUnit(sender);
                }
            }
        }

        private void OnGapcloser(AIHeroClient sender, AntiGapcloser.GapcloserArgs args)
        {
            if (sender == null || !sender.IsValid || !sender.IsEnemy)
            {
                return;
            }

            // too far
            if (args.Type == AntiGapcloser.GapcloserType.SkillShot && args.EndPosition.DistanceToPlayer() > 300f)
            {
                return;
            }

            // not player
            if (args.Type == AntiGapcloser.GapcloserType.Targeted && (args.Target == null || !args.Target.IsValid || !args.Target.IsMe))
            {
                return;
            }

            E.CastOnUnit(sender);
        }

        private void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            if (Orbwalker.ActiveMode == OrbwalkerMode.Combo)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.Harass)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.LaneClear)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.LastHit)
            {

            }
        }

        private void OnAfterAttack(object sender, AfterAttackEventArgs args)
        {
            if (Orbwalker.ActiveMode == OrbwalkerMode.Combo)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.Harass)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.LaneClear)
            {

            }
            else if (Orbwalker.ActiveMode == OrbwalkerMode.LastHit)
            {

            }
        }

        private void OnTick(EventArgs args)
        {
            if (Player == null || Player.IsDead || Player.IsRecalling())
            {
                return;
            }

            if (MenuGUI.IsChatOpen || MenuGUI.IsShopOpen)
            {
                return;
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    OnComboUpdate();
                    break;
                case OrbwalkerMode.Harass:
                    OnHarassUpdate();
                    break;
                case OrbwalkerMode.LaneClear:
                    OnLaneClearUpdate();
                    OnJungleClearUpdate();
                    break;
                case OrbwalkerMode.LastHit:
                    OnLastHitUpdate();
                    break;
            }
        }

        private void OnDraw(EventArgs args)
        {
            if (Player == null || Player.IsDead || Player.IsRecalling())
            {
                return;
            }

            if (MenuGUI.IsChatOpen || MenuGUI.IsShopOpen)
            {
                return;
            }

            if (DrawMenu["E"].GetValue<MenuBool>().Enabled)
            {
                if (DrawMenu["OnlyReady"].GetValue<MenuBool>().Enabled && E.IsReady())
                {
                    Render.Circle.DrawCircle(Player.Position, E.Range, DrawMenu["EColor"].GetValue<MenuColor>().Color.ToSystemColor());
                }
                else if (!DrawMenu["OnlyReady"].GetValue<MenuBool>().Enabled)
                {
                    Render.Circle.DrawCircle(Player.Position, E.Range, DrawMenu["EColor"].GetValue<MenuColor>().Color.ToSystemColor());
                }
            }
        }
    }
}
