// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "Kismet/GameplayStatics.h"
#include "Camera/CameraActor.h"
#include "Paddle.h"

#include "PaddlePlayerController.generated.h"

// class ABall

/**
 *
 */
UCLASS()
class MYTETRIS_API APaddlePlayerController : public APlayerController {
  GENERATED_BODY()

 public:
  APaddlePlayerController();

  UFUNCTION()
  virtual void SetupInputComponent() override;

 protected:
  virtual void BeginPlay() override;

  void MoveHorizontal(float AxisValue);
};
