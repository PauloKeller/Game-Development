// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "PaperCharacter.h"

#include "MetroidvaniaCharacter.generated.h"

/**
 * 
 */
UCLASS()
class METROIDVANIACAMCODE_API AMetroidvaniaCharacter : public APaperCharacter
{
	GENERATED_BODY()

public:
	UPROPERTY(BlueprintReadWrite, VisibleAnywhere, Category = Camera)
		class AMetroidvaniaCamera* CurrentCamera;
};
