
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

#### Destroy All Boxes

> Maybe you wanna switch to non-Vagrant-managed VMs

```sh
vagrant global-status
vagrant global-status --prune  # Remove invalid entries

# via Vagrant
vagrant destroy 9e7d547

# via the manual way
cd ~/.vagrant.d/boxes/
```

#### State

| Command | Description |
| :----- | :-----|
| `vagrant status` | Status |
| `vagrant suspend` | Sleep |
| `vagrant up` | Boot |
| `vagrant halt` | Shutdown |
| `vagrant reload` | Reboot |

### Backup

| `vagrant` | Does |
| :----- | :-----|
| `.. snapshot list` | List |
| `.. snapshot NEW_SNAPSHOT_NAME` | Create |
| `.. snapshot restore SNAP_NAME` (and `delete SNAP_NAME`) | Restore |
