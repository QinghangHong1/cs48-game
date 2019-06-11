using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class BuyItemTest
    {
        protected GameObject item;
        protected GameControl playerAttributes;
        [SetUp]
        public void setUpScene()
        {
            playerAttributes = new GameControl();
            item = new GameObject();
        }
        // A Test behaves as an ordinary method
        [Test]
        public void BuyItemTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }


    }
}
