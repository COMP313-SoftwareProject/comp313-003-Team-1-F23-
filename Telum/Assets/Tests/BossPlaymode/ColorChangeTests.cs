using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ColorChangeTests
{
    [UnityTest]
    public IEnumerator ColorChangeCheck()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        PlayerController playerMovement = player.GetComponent<PlayerController>();
        // Get the original color
        PlayerController.PlayerColor originalColor = playerMovement.currentColor;

        //Act
        playerMovement.currentColor = PlayerController.PlayerColor.Red;
        yield return null;

        //Assert
        Assert.AreNotEqual(originalColor, playerMovement.currentColor);
    }
}
