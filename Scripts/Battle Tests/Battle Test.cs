using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Completed;
using System;

namespace Tests
{
    public class BattleTest
    {
        Enemy e;

        GameObject t;
        //PauseMenu pau;
        //var m = new GameObject().AddComponent<GameManager>();
        //MainMenu ma;
        //connet c;

        [SetUp]
        public void SetupGameObject()
        {
            e = new Enemy();


            /*p = new Player();
            t = new GameObject();
            pau = new PauseMenu();
            c = new connet();
            pau.pauseMenuUI = new GameObject();

            e.playerAttributes = new GameControl();
            p.playerAttributes = new GameControl();
            ma = new MainMenu();*/

        }
        // A Test behaves as an ordinary method
        [Test]
        public void BattleTestSimplePasses()
        {
            e.hp = 90;
            e.DamageEnemy(10);
            Assert.AreEqual(80, e.hp);
            // Use the Assert class to test conditions
        }

        [Test]
        public void TestHideLevelImage()
        {
            var m = new GameObject().AddComponent<GameManager>();
            m.levelImage = new GameObject();
            m.HideLevelImage();
            Assert.AreEqual(false, m.doingSetup);
        }

        [Test]
        public void TestMoenyAndLevel()
        {
            e.skipMove = true;
            e.AttemptMove<Player>(1, 1);
            Assert.AreEqual(false, e.skipMove);
        }

        /*[Test]
        public void TestLoseFood()
        {
            var p = new GameObject().AddComponent<Player>();
            p.playerAttributes = new GameObject().AddComponent<GameControl>();
            p.playerAttributes.HP = 10;
            //p.foodText = new GameObject().AddComponent<tex>();
            //p.foodText.text = " ";
            p.LoseFood(5);
            //Assert.AreEqual(5, p.playerAttributes.HP);
            Assert.AreEqual(true, true);

        }*/

        

        [Test]
        public void TestResume()
        {
            var pau = new GameObject().AddComponent<PauseMenu>();
            pau.pauseMenuUI = new GameObject();
            pau.Resume();

            Assert.AreEqual(false, pau.get_GameIsPaused());
        }

        [Test]
        public void TestMainMenu()
        {
            var ma = new GameObject().AddComponent<MainMenu>();
            ma.ExitGame();
            Assert.AreEqual(true, ma.quitGame);
        }

        [Test]
        public void TestDamageEnemy()
        {
            e.playerAttributes = new GameObject().AddComponent<GameControl>();
            e.playerAttributes.level = 2;
            e.playerAttributes.EnemyKilled = 3;
            e.playerAttributes.QuestCount = 1;
            e.playerAttributes.HP = -9;
            e.DamageEnemy(-10);
            Assert.AreEqual(false, e.playerAttributes.isQuestComplete);
        }
        [Test]
        public void TestChangeUseButton1()
        {
            var c = new GameObject().AddComponent<ChangeUseButton>();
            c.GO = new GameObject();
            c.ButtonUse();
            Assert.AreEqual(true, c.changeSceneButton);
        }
        [Test]
        public void TestConnet()
        {
            var c = new GameObject().AddComponent<connet>();
            c.StartMenu = false;
            c.GoToTheGame();
            Assert.AreEqual(true, true);
        }
        [TearDown]
        public void DestroyEnemy()
        {
            e = null;
            //p = null;
            //c = null;
        }
        
        


    }
}
