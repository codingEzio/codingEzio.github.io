
## Vagrant

### Intro

- Find images on [Vagrant Cloud](https://app.vagrantup.com/boxes/search)
- e.g. vagrant init `centos/7` (or `ubuntu/focal64`)

### Share

#### Folder

- Edit `config.vm.synced_folder "host_folder", "/vm_folder"`

#### Port

- Edit `config.vm.network "forwarded_port", guest: 3306, host: 3307`

### Tweak

#### Resource

- Edit `config.vm.provider "virtualbox" do |vb| vb.memory = "1024" end`

#### Proxy

- Run `vagrant plugin install vagrant-proxyconf`

- Edit

```sh
# Vagrantfile
config.proxy.http     = "http://127.0.0.1:7890"
config.proxy.https    = "http://127.0.0.1:7890"
config.proxy.no_proxy = "localhost,127.0.0.1"
```

### Manage

#### State

| Command | Description |
| :----- | :-----|
| `vagrant status` | Status |
| `vagrant suspend` | Sleep |
| `vagrant up` | Boot |
| `vagrant halt` | Shutdown |
| `vagrant reload` | Reboot |

### Backup

| Command | Description |
| :----- | :-----|
| `vagrant snapshot list` | List |
| `vagrant snapshot NEW_SNAPSHOT_NAME` | Create |
| `vagrant snapshot restore SNAP_NAME` (and `delete SNAP_NAME`) | Restore |
