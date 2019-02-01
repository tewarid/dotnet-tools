# 1. GIT CHEAT SHEET

Sources  
https://services.github.com/on-demand/downloads/github-git-cheat-sheet.pdf  
https://www.atlassian.com/git/tutorials/atlassian-git-cheatsheet

## 1.1. INSTALL GIT

Git distributions for Linux and POSIX systems are available on the official Git SCM web site.

Git for All Platforms  
http://git-scm.com

Sourcetree is a free Git client for Windows and Mac  
https://www.sourcetreeapp.com/

GitHub provides desktop clients that include a graphical user interface for the most common repository actions and an automatically updating command line edition of Git for advanced scenarios.

GitHub for Windows  
https://windows.github.com

GitHub for Mac  
https://mac.github.com

Connecting to GitHub using SSH  
https://help.github.com/articles/connecting-to-github-with-ssh/

## 1.2. CONFIGURE TOOLING

Configure user information for all local repositories

Sets the name you want attached to your commit transactions

$ git config --global user.name "[name]"

Sets the email you want attached to your commit transactions

$ git config --global user.email "[email address]"

Enables helpful colorization of command line output

$ git config --global color.ui auto

## 1.3. CREATE REPOSITORIES

Start a new repository or obtain one from an existing URL

Creates a new local repository with the specified name

$ git init [project-name]

Downloads a project and its entire version history

$ git clone [url]

## 1.4. MAKE CHANGES

Review edits and craft a commit transaction

Lists all new or modified files to be committed

$ git status

Snapshots the file in preparation for versioning

$ git add [file]

Unstages the file, but preserve its contents

$ git reset [file]

Shows file differences not yet staged

$ git diff

Shows file differences between staging and the last file version

$ git diff --staged

Records file snapshots permanently in version history

$ git commit -m "[descriptive message]"

Shows which files would be removed from working directory. Use the -f flag in place of the -n flag to execute the clean.

$ git clean -n

## 1.5. GROUP CHANGES

Name a series of commits and combine completed efforts

Lists all local branches in the current repository

$ git branch

Creates a new branch

$ git branch [branch-name]

Switches to the specified branch and updates the working directory

$ git checkout [branch-name]

Combines the specified branch’s history into the current branch

$ git merge [branch]

Deletes the specified branch

$ git branch -d [branch-name]

## 1.6. REFACTOR FILENAMES

Relocate and remove versioned files

Deletes the file from the working directory and stages the deletion

$ git rm [file]

Removes the file from version control but preserves the file locally

$ git rm --cached [file]

Changes the file name and prepares it for commit

$ git mv [file-original] [file-renamed]

## 1.7. SUPPRESS TRACKING

Exclude temporary files and paths

A text file named .gitignore suppresses accidental versioning of files and paths matching the specified patterns  
*.log  
build/  
temp-*  

Lists all ignored files in this project

$ git ls-files --other --ignored --exclude-standard

## 1.8. SAVE FRAGMENTS

Shelve and restore incomplete changes

Temporarily stores all modified tracked files

$ git stash

Lists all stashed changesets

$ git stash list

Restores the most recently stashed files

$ git stash pop

Discards the most recently stashed changeset

$ git stash drop

## 1.9. REVIEW HISTORY

Browse and inspect the evolution of project files

Lists version history for the current branch

$ git log

Lists version history for a file, including renames

$ git log --follow [file]

Only display commits that have the specified file

$ git log -- [file]

Shows content differences between two branches

$ git diff [first-branch]...[second-branch]

Outputs metadata and content changes of the specified commit

$ git show [commit]

Show a log of changes to the local repository’s HEAD. Add --relative-date flag to show date info or --all to show all refs.

$ git reflog

## 1.10. REDO COMMITS

Erase mistakes and craft replacement history

Create new commit that undoes all of the changes made in [commit], then apply it to the current branch.

$ git revert [commit]

Undoes all commits after [commit], preserving changes locally

$ git reset [commit]

Discards all history and changes back to the specified commit

$ git reset --hard [commit]

Replace the last commit with the staged changes and last commit combined. Use with nothing staged to edit the last commit's message.

$ git commit --amend

Rebase the current branch onto [base]. [base] can be a commit ID, a branch name, a tag, or a relative reference to HEAD.

$ git rebase [base]

## 1.11. SYNCHRONIZE CHANGES

Register a repository bookmark and exchange version history

Downloads all history from the repository bookmark

$ git fetch [bookmark]

Combines bookmark’s branch into current local branch

$ git merge [bookmark]/[branch]

Uploads all local branch commits to Git

$ git push [alias] [branch]

Forces the git push even if it results in a non-fast-forward merge. Do not use the --force flag unless you’re absolutely sure you know what you’re doing.

$ git push --force [remote]

Downloads bookmark history and incorporates changes

$ git pull
