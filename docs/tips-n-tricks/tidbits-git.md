
## Git

| 操作                     | 命令                      | 备注         |
|:--------------------------|:---------------------------|:--------------|
| 应用暂存更改             | `git stash apply n`       | 最后进先出   |
| 重写提交信息             | `git rebase -i HEAD~3`   | 修改未推送信息 (还没 `git push` 的)  |
| 将未推送提交退回到暂存区 | `git reset HEAD~n`        | 退回暂存区 (还没 `git push` 的)  |
| 关于垃圾回收的说明       | `git gc`                  | 不会移除暂存 |
| `git push` 失败 | `git config http.postBuffer 524288000` | 首次 `push` [超出默认配置大小](https://stackoverflow.com/questions/62753648/rpc-failed-http-400-curl-22-the-requested-url-returned-error-400-bad-request) |