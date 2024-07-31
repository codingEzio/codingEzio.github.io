
## Tip

### JetBrains IDE

#### Drag to Snap

> Tweak via `Registry`

- old: `ide.tabbedPane.dragOutMultiplier -> 0.1`
- new `ide.tabbedPane.dragOutMultiplier -> 2`

### VS Code

#### Export Extensions

```sh
code --list-extensions > EXT_VSCODE_LIST.txt
```

#### Install Extensions

```sh
cat ~/EXT_VSCODE_LIST.txt \
    | xargs -L 1 echo code --install-extension \
    | % { "code --install-extension $_” }
```

#### Issues with Plugin *PlantUML*

> Install these fonts first to avoid the error

- Times
- Lucida Bright
