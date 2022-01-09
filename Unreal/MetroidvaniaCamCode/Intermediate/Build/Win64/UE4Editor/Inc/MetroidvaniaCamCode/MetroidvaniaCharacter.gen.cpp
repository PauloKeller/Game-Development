// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "MetroidvaniaCamCode/MetroidvaniaCharacter.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeMetroidvaniaCharacter() {}
// Cross Module References
	METROIDVANIACAMCODE_API UClass* Z_Construct_UClass_AMetroidvaniaCharacter_NoRegister();
	METROIDVANIACAMCODE_API UClass* Z_Construct_UClass_AMetroidvaniaCharacter();
	PAPER2D_API UClass* Z_Construct_UClass_APaperCharacter();
	UPackage* Z_Construct_UPackage__Script_MetroidvaniaCamCode();
	METROIDVANIACAMCODE_API UClass* Z_Construct_UClass_AMetroidvaniaCamera_NoRegister();
// End Cross Module References
	void AMetroidvaniaCharacter::StaticRegisterNativesAMetroidvaniaCharacter()
	{
	}
	UClass* Z_Construct_UClass_AMetroidvaniaCharacter_NoRegister()
	{
		return AMetroidvaniaCharacter::StaticClass();
	}
	struct Z_Construct_UClass_AMetroidvaniaCharacter_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_CurrentCamera_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_CurrentCamera;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AMetroidvaniaCharacter_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_APaperCharacter,
		(UObject* (*)())Z_Construct_UPackage__Script_MetroidvaniaCamCode,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMetroidvaniaCharacter_Statics::Class_MetaDataParams[] = {
		{ "Comment", "/**\n * \n */" },
		{ "HideCategories", "Navigation" },
		{ "IncludePath", "MetroidvaniaCharacter.h" },
		{ "ModuleRelativePath", "MetroidvaniaCharacter.h" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AMetroidvaniaCharacter_Statics::NewProp_CurrentCamera_MetaData[] = {
		{ "Category", "Camera" },
		{ "ModuleRelativePath", "MetroidvaniaCharacter.h" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AMetroidvaniaCharacter_Statics::NewProp_CurrentCamera = { "CurrentCamera", nullptr, (EPropertyFlags)0x0010000000020005, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AMetroidvaniaCharacter, CurrentCamera), Z_Construct_UClass_AMetroidvaniaCamera_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AMetroidvaniaCharacter_Statics::NewProp_CurrentCamera_MetaData, UE_ARRAY_COUNT(Z_Construct_UClass_AMetroidvaniaCharacter_Statics::NewProp_CurrentCamera_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AMetroidvaniaCharacter_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AMetroidvaniaCharacter_Statics::NewProp_CurrentCamera,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_AMetroidvaniaCharacter_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AMetroidvaniaCharacter>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AMetroidvaniaCharacter_Statics::ClassParams = {
		&AMetroidvaniaCharacter::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		Z_Construct_UClass_AMetroidvaniaCharacter_Statics::PropPointers,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		UE_ARRAY_COUNT(Z_Construct_UClass_AMetroidvaniaCharacter_Statics::PropPointers),
		0,
		0x009000A4u,
		METADATA_PARAMS(Z_Construct_UClass_AMetroidvaniaCharacter_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_AMetroidvaniaCharacter_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AMetroidvaniaCharacter()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AMetroidvaniaCharacter_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AMetroidvaniaCharacter, 4082491397);
	template<> METROIDVANIACAMCODE_API UClass* StaticClass<AMetroidvaniaCharacter>()
	{
		return AMetroidvaniaCharacter::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AMetroidvaniaCharacter(Z_Construct_UClass_AMetroidvaniaCharacter, &AMetroidvaniaCharacter::StaticClass, TEXT("/Script/MetroidvaniaCamCode"), TEXT("AMetroidvaniaCharacter"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AMetroidvaniaCharacter);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
