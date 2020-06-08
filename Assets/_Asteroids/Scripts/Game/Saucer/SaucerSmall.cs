﻿using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Small saucer object based on saucer object.
    /// </summary>
    public class SaucerSmall : Saucer
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == Constants.Tags.PLAYER_BULLET_TAG)
            {
                SpaceObject spaceObject = collision.GetComponent<SpaceObject>();
                health -= spaceObject.damage;
                //Destroy(collision.gameObject);
                collision.gameObject.SetActive(false);

                if (health <= 0)
                {
                    GameActions.AddScore(rewardScore);
                    GameActions.DestroySmallSaucer();
                }
            }
            else if (collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.AddScore(rewardScore);
                GameActions.DestroySmallSaucer();
                GameActions.DestroyPlayer();
            }
        }
    }
}