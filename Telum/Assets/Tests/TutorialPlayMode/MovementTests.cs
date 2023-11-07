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
        SceneManager.LoadScene("Tutorial");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        float originalX = player.transform.position.x;

        //Act
        player.GetComponent<PlayerMovement>().xInput = 1;
        player.GetComponent<PlayerMovement>().Move();
        yield return new WaitForFixedUpdate();

        //Assert
        Assert.Greater(player.transform.position.x, originalX);

    }

    [UnityTest]
    public IEnumerator PlayerMovesLeft(){
        SceneManager.LoadScene("Tutorial");
        yield return null;

        //Arrange
        GameObject player = GameObject.Find("Player");
        float originalX = player.transform.position.x;

        //Act
        player.GetComponent<PlayerMovement>().xInput = -1;
        player.GetComponent<PlayerMovement>().Move();
        yield return new WaitForFixedUpdate();

        //Assert
        Assert.Less(player.transform.position.x, originalX);
    }
}
