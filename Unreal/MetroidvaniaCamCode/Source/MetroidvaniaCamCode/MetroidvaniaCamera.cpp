// Fill out your copyright notice in the Description page of Project Settings.


#include "MetroidvaniaCamera.h"

// Sets default values
AMetroidvaniaCamera::AMetroidvaniaCamera()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	Root = CreateDefaultSubobject<USphereComponent>(TEXT("Root"));
	SetRootComponent(Root);

	Camera = CreateDefaultSubobject<UCameraComponent>(TEXT("Camera"));
	Camera->SetupAttachment(Root);

	PlayerTriggerBox = CreateDefaultSubobject<UBoxComponent>(TEXT("PlayerTriggerBox"));
	PlayerTriggerBox->SetupAttachment(Root);

	PlayerTriggerBox->SetRelativeTransform(PlayerTriggerTransform);
	PlayerTriggerBox->SetBoxExtent(PlayerTriggerExtent);
	PlayerTriggerBox->OnComponentBeginOverlap.AddDynamic(this, &AMetroidvaniaCamera::TriggerEnter);
}

// Called when the game starts or when spawned
void AMetroidvaniaCamera::BeginPlay() {
	Super::BeginPlay();

	GetWorld()->GetTimerManager().SetTimer(UnusedHandle, this, &AMetroidvaniaCamera::BeginPlayDelay, 0.0f, false);
}

// Called every frame
void AMetroidvaniaCamera::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}


void AMetroidvaniaCamera::TriggerEnter(class UPrimitiveComponent* OverlappedComponen, AActor* OtherActor, UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult) {
	AMetroidvaniaCharacter* MetroidvaniaCharacter = Cast<AMetroidvaniaCharacter>(OtherActor);
	MetroidvaniaCharacter->CurrentCamera = this;
	GetWorld()->GetFirstPlayerController()->SetViewTargetWithBlend(this);
}

void AMetroidvaniaCamera::BeginPlayDelay() {
	AActor* OtherActor = GetWorld()->GetFirstPlayerController()->GetPawn();
	AMetroidvaniaCharacter* MetroidvaniaCharacter = Cast<AMetroidvaniaCharacter>(OtherActor);

	TArray<UPrimitiveComponent*> OverlappedComponents;

	MetroidvaniaCharacter->GetOverlappingComponents(OverlappedComponents);
	for (UPrimitiveComponent* Component : OverlappedComponents) {
		if (Component == PlayerTriggerBox) {
			MetroidvaniaCharacter->CurrentCamera = this;
			GetWorld()->GetFirstPlayerController()->SetViewTargetWithBlend(this);
		}
	}
}