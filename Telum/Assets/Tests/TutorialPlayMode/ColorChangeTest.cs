using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ColorChangeTest
{
    [UnityTest]
    public IEnumerator ColorChangeCheck()
    {
        SceneManager.LoadScene("Tutorial");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        // Get the original color
        PlayerMovement.PlayerColor originalColor = playerMovement.currentColor;

        //Act
        playerMovement.currentColor = PlayerMovement.PlayerColor.Red;
        yield return null;

        //Assert
        Assert.AreNotEqual(originalColor, playerMovement.currentColor);
    }
}
