// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Components/SphereComponent.h"
#include "Camera/CameraComponent.h"
#include "Components/BoxComponent.h"
#include "MetroidvaniaCharacter.h"

#include "MetroidvaniaCamera.generated.h"

UCLASS()
class METROIDVANIACAMCODE_API AMetroidvaniaCamera : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AMetroidvaniaCamera();

	UPROPERTY(BlueprintReadWrite, VisibleAnywhere, Category = Camera)
		USphereComponent* Root;

	UPROPERTY(BlueprintReadWrite, VisibleAnywhere, Category = Camera)
		UCameraComponent* Camera;

	UPROPERTY(BlueprintReadWrite, VisibleAnywhere, Category = Camera)
		UBoxComponent* PlayerTriggerBox;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = Camera)
		FTransform PlayerTriggerTransform;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = Camera)
		FVector PlayerTriggerExtent;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	FTimerHandle UnusedHandle;

	UFUNCTION()
	void TriggerEnter(class UPrimitiveComponent* OverlappedComponent, AActor* OtherActor, UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult);
	
	void BeginPlayDelay();

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
};
