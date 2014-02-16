#include "Game.h"

void Game::LoadContent()
{
	//-- Load Fonts, Images, Colours, Music
	// Fonts

	ClientAPI::AddFont("Systema_11", APIHelper::LoadFont("Resources/Fonts/9SYSTEMA.ttf", 11));
	ClientAPI::AddFont("Systema_22", APIHelper::LoadFont("Resources/Fonts/9SYSTEMA.ttf", 22));

	// Colours
	ClientAPI::AddColour("Black", APIHelper::ColourHelper(0, 0, 0, 255));
	ClientAPI::AddColour("White", APIHelper::ColourHelper(255, 255, 255, 255));
	ClientAPI::AddColour("Red", APIHelper::ColourHelper(255, 0, 0, 255));
	ClientAPI::AddColour("Blue", APIHelper::ColourHelper(0, 255, 0, 255));
	ClientAPI::AddColour("Green", APIHelper::ColourHelper(0, 0, 255, 255));

	// Convienent Rects
	ClientAPI::AddRect("Logo", APIHelper::RectHelper(0, 0, 0, 0));
	ClientAPI::AddRect("Background", APIHelper::RectHelper(0, 0, Window::Box().w, Window::Box().h));

	ClientAPI::AddRect("smallButton", APIHelper::RectHelper(0, 0, 35, 35));
	ClientAPI::AddRect("mediumButton", APIHelper::RectHelper(0, 0, 95, 35));
	ClientAPI::AddRect("longButton", APIHelper::RectHelper(0, 0, 180, 35));

	// Textures
	ClientAPI::AddTexture("SmallBtnNormal", APIHelper::LoadBMPImage("Resources/GUITextures/smallBtnNormal.bmp"));
	ClientAPI::AddTexture("MedBtnNormal", APIHelper::LoadBMPImage("Resources/GUITextures/medBtnNormal.bmp"));
	ClientAPI::AddTexture("LongBtnNormal", APIHelper::LoadBMPImage("Resources/GUITextures/longBtnNormal.bmp"));

	ClientAPI::AddTexture("MainMenu Background", APIHelper::SolidColourTexture(51, 51, ClientAPI::GetColor("White")));
	ClientAPI::AddTexture("Logo", APIHelper::SolidColourTexture(1, 1, ClientAPI::GetColor("Black")));

	//-- Load Menus
	MainMenu::Load();
}

void Game::Update(double time)
{

}

void Game::Draw()
{

}

void Game::OnEscapePressed()
{

}

void Game::OnEnterPressed()
{

}