using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BossColorTests
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator BossColorChangeViaHealth()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;
        //Arrange
        GameObject boss = GameObject.Find("Boss");
        if (boss == null)
        {
            Assert.Fail("Boss not found");
        }

        Boss bossController = boss.GetComponent<Boss>();
        if(bossController == null)
        {
            Assert.Fail("Boss controller not found");
        }

        float health = boss.GetComponent<Boss>().health;
        Boss.BossColor originalColor = bossController.currentColor;

        //Act
        bossController.health = 7;
        bossController.Update();

        //Assert
        Assert.AreNotEqual(originalColor, bossController.currentColor);

    }

}
