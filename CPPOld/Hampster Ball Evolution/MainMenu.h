#pragma once
#include "ClientAPI.h"

class MainMenu
{
public:
	static void Load()
	{
		// Create the Gui Container
		ClientAPI::AddGuiContainer("Main Menu", new GuiContainer());

		// Set up the events on container
		ClientAPI::GetGuiContainer("Main Menu")->SubscribeOnEnterKeyPressed(MainMenu::OnEnterPressed);
		ClientAPI::GetGuiContainer("Main Menu")->SubscribeOnEscapeKeyPressed(MainMenu::OnEscapePressed);

		//-- Begin
		ClientAPI::GetGuiContainer("Main Menu")->AddGuiElement("Background", new GuiElement(ClientAPI::GetTexture("MainMenu Background"), APIHelper::RectHelper(0,0,Window::Box().w,Window::Box().h)));
		ClientAPI::GetGuiContainer("Main Menu")->AddGuiElement("Logo", new GuiElement(ClientAPI::GetTexture("Logo"), ClientAPI::GetRect("Logo")));

		// Play Button
		ClientAPI::GetGuiContainer("Main Menu")->AddButton("Play Game", new Button(ClientAPI::GetTexture("LongBtnNormal"), ClientAPI::GetRect("longButton")));
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Play Game")->SetPosition(200, 200);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Play Game")->AddLabel("Play Game", ClientAPI::GetFont("Systema_22"), ClientAPI::GetColor("Black"), true);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Play Game")->GetLabel()->SetPadding({ 25, 2, 0, 0 });
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Play Game")->SubscribeOnMouseClick(MainMenu::OnClick_PlayGameClicked);

		// Options Button
		ClientAPI::GetGuiContainer("Main Menu")->AddButton("Options", new Button(ClientAPI::GetTexture("LongBtnNormal"), ClientAPI::GetRect("longButton")));
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Options")->SetPosition(200, 250);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Options")->AddLabel("Options", ClientAPI::GetFont("Systema_22"), ClientAPI::GetColor("Black"), true);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Options")->GetLabel()->SetPadding({ 40, 2, 0, 0 });
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Options")->SubscribeOnMouseClick(MainMenu::OnClick_OptionsClicked);

		// Quit Button
		ClientAPI::GetGuiContainer("Main Menu")->AddButton("Exit Game", new Button(ClientAPI::GetTexture("LongBtnNormal"), ClientAPI::GetRect("longButton")));
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Exit Game")->SetPosition(200, 300);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Exit Game")->AddLabel("Exit", ClientAPI::GetFont("Systema_22"), ClientAPI::GetColor("Black"), true);
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Exit Game")->GetLabel()->SetPadding({ 60, 2, 0, 0 });
		ClientAPI::GetGuiContainer("Main Menu")->GetButton("Exit Game")->SubscribeOnMouseClick(MainMenu::OnClick_QuitClicked);
	}
	
	static void OnClick_PlayGameClicked()
	{

	}

	static void OnClick_OptionsClicked()
	{

	}

	static void OnEnterPressed() { }

	static void OnClick_QuitClicked() { ClientAPI::Quit(); }
	static void OnEscapePressed() { ClientAPI::Quit(); }
};