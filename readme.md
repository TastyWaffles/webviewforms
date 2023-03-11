# WebViewForms demo

# Note: Do not edit `MainForm.Designer.cs` directly!

## Build Web

`cd web`

`yarn`

`yarn build`

## Build WinForm

`dotnet build`

## Debug (VSCode)

Copy web/dist/index.html to bin/debug/&lt;platform&gt;/web/

Run `Launch Edge` configuration to launch the application and debug web

Then (optionally) run `.NET Core Attach` configuration to attach C# debugger

## Publishing

TBD

## TODO

- Remove need to manually copy web distributables
- Determine publishing methodology
- Investigate limitations of single-file HTML