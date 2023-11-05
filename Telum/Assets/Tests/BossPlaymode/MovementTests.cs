using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MovementTests
{
    [UnityTest]
    public IEnumerator PlayerMovesRight()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Assert.Fail("Player not found");
        }
        float originalX = player.transform.position.x;

        //Act
        player.GetComponent<PlayerController>().horizontalInput += 1;
        yield return new WaitForFixedUpdate();
        player.GetComponent<PlayerController>().horizontalInput = 0;
        yield return new WaitForFixedUpdate();

        //Assert
        Assert.Greater(player.transform.position.x, originalX);


    }


    [UnityTest]
    public IEnumerator PlayerMovesLeft()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Assert.Fail("Player not found");
        }
        float originalX = player.transform.position.x;

        //Act
        player.GetComponent<PlayerController>().horizontalInput -= 1;
        yield return new WaitForFixedUpdate();
        player.GetComponent<PlayerController>().horizontalInput = 0;
        yield return new WaitForFixedUpdate();

        //Assert
        Assert.Less(player.transform.position.x, originalX);


    }

}
