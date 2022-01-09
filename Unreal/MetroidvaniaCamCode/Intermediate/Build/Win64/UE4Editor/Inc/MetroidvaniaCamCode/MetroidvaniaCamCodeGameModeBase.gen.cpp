// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "MetroidvaniaCamCode/MetroidvaniaCamCodeGameModeBase.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeMetroidvaniaCamCodeGameModeBase() {}
// Cross Module References
	METROIDVANIACAMCODE_API UClass* Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_NoRegister();
	METROIDVANIACAMCODE_API UClass* Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_MetroidvaniaCamCode();
// End Cross Module References
	void AMetroidvaniaCamCodeGameModeBase::StaticRegisterNativesAMetroidvaniaCamCodeGameModeBase()
	{
	}
	UClass* Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_NoRegister()
	{
		return AMetroidvaniaCamCodeGameModeBase::StaticClass();
	}
	struct Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AGameModeBase,
		(UObject* (*)())Z_Construct_UPackage__Script_MetroidvaniaCamCode,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::Class_MetaDataParams[] = {
		{ "Comment", "/**\n * \n */" },
		{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
		{ "IncludePath", "MetroidvaniaCamCodeGameModeBase.h" },
		{ "ModuleRelativePath", "MetroidvaniaCamCodeGameModeBase.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AMetroidvaniaCamCodeGameModeBase>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::ClassParams = {
		&AMetroidvaniaCamCodeGameModeBase::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		0,
		0,
		0x009002ACu,
		METADATA_PARAMS(Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AMetroidvaniaCamCodeGameModeBase, 1954038966);
	template<> METROIDVANIACAMCODE_API UClass* StaticClass<AMetroidvaniaCamCodeGameModeBase>()
	{
		return AMetroidvaniaCamCodeGameModeBase::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AMetroidvaniaCamCodeGameModeBase(Z_Construct_UClass_AMetroidvaniaCamCodeGameModeBase, &AMetroidvaniaCamCodeGameModeBase::StaticClass, TEXT("/Script/MetroidvaniaCamCode"), TEXT("AMetroidvaniaCamCodeGameModeBase"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AMetroidvaniaCamCodeGameModeBase);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
