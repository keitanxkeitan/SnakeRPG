using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyDefine
{
    public enum EnemyType
    {
        Bat,
        Crab,
        Devil,
        Dog,
        Dragon,
        Eyeball,
        GreenMan,
        Helmet,
        Lip,
        Pig,
        PotatoMan,
        Skeleton,
        Slime,
        Weed,
        Size
    };

    public static EnemyParameters GetParameters(EnemyType type) {
        EnemyParameters parameters = new EnemyParameters();
        switch(type) {
            default:
                parameters.mAttackTime = 0.8f;
                parameters.mAttackPower = 1.0f;
                parameters.mLife = 2.0f;
                break;
            case EnemyType.Dog:
                parameters.mAttackTime = 0.4f;
                parameters.mAttackPower = 1.0f;
                parameters.mLife = 1.0f;
                break;
            case EnemyType.Slime:
                parameters.mAttackTime = 1.5f;
                parameters.mAttackPower = 2.0f;
                parameters.mLife = 1.0f;
                break;
            case EnemyType.Devil:
                parameters.mAttackTime = 1.5f;
                parameters.mAttackPower = 2.0f;
                parameters.mLife = 3.0f;
                break;
            case EnemyType.Dragon:
                parameters.mAttackTime = 2.0f;
                parameters.mAttackPower = 5.0f;
                parameters.mLife = 4.0f;
                break;
        }
        return parameters;
    }
}
